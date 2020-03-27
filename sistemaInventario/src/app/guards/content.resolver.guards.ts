import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Servidor } from '../model/servidor.model';
import { MethodService } from '../services/method.service';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class ContentResolverGuard implements Resolve<Servidor> {

    constructor(
        private method: MethodService
    ) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Servidor> {
        if (route.params && route.params['id']) {
            return this.method.idServidor(route.params['id']);
        }
    }

}
