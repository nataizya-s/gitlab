import { Component, OnInit, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AppAuthService } from '@shared/auth/app-auth.service';
import { SchoolServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
    templateUrl: './sidebar-user-area.component.html',
    selector: 'sidebar-user-area',
    encapsulation: ViewEncapsulation.None
})
export class SideBarUserAreaComponent extends AppComponentBase implements OnInit {

    shownLoginName = '';
    logoLocation: string = null;

    constructor(
        injector: Injector,
        private _authService: AppAuthService,
        private schoolService: SchoolServiceProxy
    ) {
        super(injector);
    }

    ngOnInit() {
        this.shownLoginName = this.appSession.getShownLoginName();
        if (this.appSession.tenantId === null) return;
        this.schoolService.getLogoLocation(this.appSession.tenantId)
            .subscribe((location: string) => {
                this.logoLocation = location;
            });
    }

    logout(): void {
        this._authService.logout();
    }

    setStyle() {
        let location: string = "../assets/images/user-img-background.jpg";
        if (this.logoLocation != null) {
            location = ".." + this.logoLocation.replace(/\\/g, "/");
        }
        let styles = {
            'background-image': 'url(' + location + ')'
        };
        return styles;
    }

}
