import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ItemListItemModel } from '../../../models';

@Component({
    selector: 'app-item-selected',
    templateUrl: './item.selected.component.html'
})

export class ItemSelectedComponent {
    @Input() selectedItems: Array<ItemListItemModel> = new Array<ItemListItemModel>();
    @Input() readOnly: boolean;
    @Output() deleteItem = new EventEmitter();
}

