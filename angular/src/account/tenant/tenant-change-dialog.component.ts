import { Component, Injector } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import { AccountServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppTenantAvailabilityState } from '@shared/AppEnums';
import {
    IsTenantAvailableInput,
    IsTenantAvailableOutput
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './tenant-change-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
    `
    ]
})
export class TenantChangeDialogComponent extends AppComponentBase {
    saving = false;
    schoolName = '';

    constructor(
        injector: Injector,
        private _accountService: AccountServiceProxy,
        private _dialogRef: MatDialogRef<TenantChangeDialogComponent>
    ) {
        super(injector);
    }

    save(): void {
        if (!this.schoolName) {
            abp.multiTenancy.setTenantIdCookie(undefined);
            this.close(true);
            location.reload();
            return;
        }

        const input = new IsTenantAvailableInput();
        input.tenancyName = this.schoolName;

        this.saving = true;
        this._accountService
            .isTenantAvailable(input)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((result: IsTenantAvailableOutput) => {
                switch (result.state) {
                    case AppTenantAvailabilityState.Available:
                        abp.multiTenancy.setTenantIdCookie(result.tenantId);
                        this.close(true);
                        location.reload();
                        return;
                    case AppTenantAvailabilityState.InActive:
                        this.message.warn(this.l('TenantIsNotActive', this.schoolName));
                        break;
                    case AppTenantAvailabilityState.NotFound:
                        this.message.warn(
                            this.l('ThereIsNoTenantDefinedWithName{0}', this.schoolName)
                        );
                        break;
                }
            });
    }

    close(result?: any): void {
        this._dialogRef.close(result);
    }
}
