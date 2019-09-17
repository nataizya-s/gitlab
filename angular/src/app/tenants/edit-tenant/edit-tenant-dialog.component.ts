import { Component, Injector, OnInit, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
    TenantServiceProxy,
    TenantDto,
    SchoolServiceProxy
} from '@shared/service-proxies/service-proxies';
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { AppConsts } from "shared/AppConsts";
import { TokenService } from '@abp/auth/token.service';
import { IAjaxResponse } from '@abp/abpHttpInterceptor';
import { Observable } from "rxjs/Rx";

@Component({
    templateUrl: 'edit-tenant-dialog.component.html',
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
export class EditTenantDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    tenant: TenantDto = new TenantDto();
    public uploader: FileUploader;
    _uploaderOptions: FileUploaderOptions = {};
    fileName: string;
    logoLocation: string = null;

    constructor(
        injector: Injector,
        public _tenantService: TenantServiceProxy,
        private _dialogRef: MatDialogRef<EditTenantDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number,
        private tokenService: TokenService,
        private schoolService: SchoolServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        Observable.forkJoin([
            this._tenantService.get(this._id),
            this.schoolService.getLogoLocation(this._id)
        ])
            .subscribe((results: any[]) => {
                this.tenant = results[0];
                this.logoLocation = results[1];
            });

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
                this.tenant.profilePhotoAttachmentId = resp.result;
            } else
                this.message.error(resp.error.message);
        };

        this.uploader.setOptions(this._uploaderOptions);


    }

    save(): void {
        this.saving = true;

        this._tenantService
            .update(this.tenant)
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

    logo(): string {
        return `..${this.logoLocation.replace(/\\/g, "/")}`;

    }
}
