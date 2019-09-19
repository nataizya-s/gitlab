import { Component, Injector, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
    CreateTenantDto,
    TenantServiceProxy,
    FileParameter,
    AddressDto,
    ContactDto
} from '@shared/service-proxies/service-proxies';
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { AppConsts } from "shared/AppConsts";
import { TokenService } from '@abp/auth/token.service';
import { IAjaxResponse } from '@abp/abpHttpInterceptor';

@Component({
    templateUrl: 'create-tenant-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class CreateTenantDialogComponent extends AppComponentBase implements OnInit {
    saving = false;
    tenant: CreateTenantDto = new CreateTenantDto();
    public uploader: FileUploader;
    _uploaderOptions: FileUploaderOptions = {};
    fileName: string;
    @Output() uploadOutput: EventEmitter<any> = new EventEmitter<any>();
    addressTypes: any[] = AppConsts.addressTypes;
    contactTypes: any[] = AppConsts.contactTypes;

    constructor(
        injector: Injector,
        public _tenantService: TenantServiceProxy,
        private _dialogRef: MatDialogRef<CreateTenantDialogComponent>,
        private tokenService: TokenService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.tenant.isActive = true;
        this.tenant.addresses = [];
        this.tenant.addresses.push(new AddressDto());
        this.tenant.contacts = [];
        this.tenant.contacts.push(new ContactDto());


        this.uploader = new FileUploader({ url: AppConsts.remoteServiceBaseUrl + "/api/services/app/Tenant/UploadFile" });
        this.uploader.clearQueue();
        this._uploaderOptions.autoUpload = true;
        this._uploaderOptions.authToken = `Bearer ${this.tokenService.getToken()}`;
        this._uploaderOptions.removeAfterUpload = false;
        this._uploaderOptions.maxFileSize = 8 * 1024 * 1024; // 8 MB
        this._uploaderOptions.allowedFileType = ["image"];
        this.uploader.onAfterAddingFile = (file) => {
            file.withCredentials = false;
            this.saving = true;
        };

        this.uploader.onBuildItemForm = (fileItem: FileItem, form: any) => {
            this.fileName = fileItem.file.name;
            form.append('FileType', fileItem.file.type);
            form.append('FileName', fileItem.file.name);
            form.append('TenantId', this.appSession.tenantId);
        };

        this.uploader.onSuccessItem = (item, response, status) => {
            this.saving = false;
            const resp = JSON.parse(response) as IAjaxResponse;
            if (resp.success) {
                this.tenant.schoolLogoAttachmentId = resp.result;
            } else
                this.message.error(resp.error.message);
        };

        this.uploader.setOptions(this._uploaderOptions);
    }

    save(): void {
        this.saving = true;

        this._tenantService
            .create(this.tenant)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close(true);
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
