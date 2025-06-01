import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SalesRepService } from '../../services/sales-rep';
import { SalesRepresentative } from '../../models/sales-representative.model';

@Component({
  selector: 'app-sales-reps',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sales-reps.component.html',
  styleUrls: ['./sales-reps.component.scss']
})
export class SalesRepsComponent implements OnInit {
  salesReps: SalesRepresentative[] = [];

  newRep = {
    name: '',
    email: '',
    platform: '',
    region: '',
    isActive: false
  };

  editingIndex: number | null = null;
  editRep: SalesRepresentative = {
    id: 0, name: '', email: '', platform: '', region: '', isActive: false
  };

  products: string[] = ['Product A', 'Product B', 'Product C']; 
  regions: string[] = ['North', 'South', 'East', 'West']; 
  platforms: string[] = ['Amazon', 'Ebay', 'Shopify']; 

  selectedProduct: string = '';
  selectedRegion: string = '';
  selectedPlatform: string = '';

  filteredReps: SalesRepresentative[] = [];

  constructor(private salesRepService: SalesRepService) {}

  ngOnInit(): void {
    console.log('SalesRepsComponent loaded');
    this.loadReps();
  }

  addRep() {
    if (
      this.newRep.name &&
      this.newRep.email &&
      this.newRep.platform &&
      this.newRep.region
    ) {
      this.salesRepService.add(this.newRep).subscribe(addedRep => {
        this.salesReps.push(addedRep); 
        this.applyFilters(); 
        // Reset form
        this.newRep = {
          name: '',
          email: '',
          platform: '',
          region: '',
          isActive: false
        };
      });
    }
  }

  deleteRep(index: number) {
    const rep = this.filteredReps[index];
    if (!rep) return;
    this.salesRepService.delete(rep.id).subscribe(() => {
      this.loadReps();
    });
  }

  startEdit(index: number) {
    this.editingIndex = index;
    this.editRep = { ...this.filteredReps[index] };
  }

  cancelEdit() {
    this.editingIndex = null;
  }

  saveEdit() {
    if (this.editingIndex !== null) {
      const rep = this.editRep;
      this.salesRepService.update(rep.id, rep).subscribe(() => {
        this.loadReps();
        this.editingIndex = null;
      });
    }
  }

  loadReps() {
    this.salesRepService.getAll(this.selectedPlatform, this.selectedRegion).subscribe(data => {
      this.salesReps = data;
      this.applyFilters();
    });
  }

  applyFilters() {
    this.salesRepService.getAll(this.selectedPlatform, this.selectedRegion).subscribe(data => {
      this.filteredReps = data;
    });
  }
}
