import { Component, OnInit } from '@angular/core';
import { PaymentDetailsService } from 'src/app/shared/payment-details.service';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-detail-list',
  templateUrl: './payment-detail-list.component.html',
  styles: []
})
export class PaymentDetailListComponent implements OnInit {

  constructor(private service:PaymentDetailsService,private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }
  
  populateForm(pd:PaymentDetail){
    this.service.formData=Object.assign({},pd);
  }

  onDelete(PMID)
  {
    alert(PMID);
    if(confirm('Do you want to delete this record'))
    {
      this.service.deletePaymentDetail(PMID).subscribe(
        res=> {
          this.service.refreshList();
          this.toastr.warning('Deleted successfuly','Payment details')
          
      })
    }
  }
}
