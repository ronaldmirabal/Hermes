import { MatDialogRef } from '@angular/material/dialog';
import { Component } from '@angular/core';


@Component({
    templateUrl: 'dialogdelete.component.html'
})

export class DialogDeleteComponent{
    constructor(public dialogRef: MatDialogRef<DialogDeleteComponent>){
        
    }
}