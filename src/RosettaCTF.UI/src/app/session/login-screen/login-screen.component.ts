// This file is part of RosettaCTF project.
//
// Copyright 2020 Emzi0767
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { RosettaApiService } from "src/app/services/rosetta-api.service";
import { ILoginSettings, IUserLogin } from "src/app/data/api";
import { ErrorDialogComponent } from "src/app/dialog/error-dialog/error-dialog.component";
import { EventDispatcherService } from "src/app/services/event-dispatcher.service";
import { SessionProviderService } from "src/app/services/session-provider.service";

@Component({
    selector: "app-login-screen",
    templateUrl: "./login-screen.component.html",
    styleUrls: ["./login-screen.component.less"]
})
export class LoginScreenComponent implements OnInit {

    loginModel: IUserLogin = { username: null, password: null };

    lockControls = false;
    loginSettings: ILoginSettings = null;

    constructor(private api: RosettaApiService,
                private eventDispatcher: EventDispatcherService,
                private router: Router,
                private sessionProvider: SessionProviderService) { }

    ngOnInit(): void {
        this.doInit();
    }

    async loginSubmit(): Promise<void> {
        this.lockControls = true;
        const loginResult = await this.api.login(this.loginModel);
        if (!loginResult.isSuccess) {
            this.eventDispatcher.emit("dialog",
                {
                    componentType: ErrorDialogComponent,
                    defaults:
                    {
                        message: !!loginResult.error?.message
                            ? `Could not log in. Please try again.\n\nIf the problem persists, contact the organizers, with the following error message: ${loginResult.error.message} (${loginResult.error.code})`
                            : "Could not log in. Please try again.\n\nIf the problem persists, contact the organizers."
                    }
                });

            this.lockControls = false;
            return;
        }

        this.sessionProvider.updateSession(loginResult.result);
        await this.api.refreshXsrf();
        this.router.navigate(["/"]);
    }

    private async doInit(): Promise<void> {
        const data = await this.api.getLoginSettings();
        if (!data.isSuccess) {
            this.eventDispatcher.emit("dialog",
                {
                    componentType: ErrorDialogComponent,
                    defaults:
                    {
                        message: !!data.error?.message
                            ? `Could not retrieve login settings. Please try again.\n\nIf the problem persists, contact the organizers, with the following error message: ${data.error.message} (${data.error.code})`
                            : "Could not retrieve login settings. Please try again.\n\nIf the problem persists, contact the organizers."
                    }
                });

            this.router.navigate(["/"]);
            return;
        }

        this.loginSettings = data.result;
    }
}