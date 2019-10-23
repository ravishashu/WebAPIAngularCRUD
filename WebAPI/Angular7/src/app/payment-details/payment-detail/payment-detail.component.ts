import { Component, OnInit } from '@angular/core';
import { PaymentDetailsService } from 'src/app/shared/payment-details.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {

  constructor(private service:PaymentDetailsService,private toastr: ToastrService) { }

  ngOnInit() {
  this.resetForm();
  }

  resetForm(form?:NgForm)
  {
    if(form!=null)
    form.resetForm();
    this.service.formData={
      PMID:0,
      CardHolderName:'',
      CardNumber:'',
      ExpireDate:'',
      CVV:''
    }
  }

  onSubmit(form: NgForm) 
  {
    if(form.value.PMID==0)
    {
      this.insertRecord(form);
    }
    else
    {
      this.updateRecord(form);      
    }
  }

  insertRecord(form: NgForm)
  {
    this.service.postPaymentDetail().subscribe(
      res=>{ 
        this.resetForm(form);
        this.toastr.success('Successfully saved' ,'Payment details');
        this.service.refreshList();
     },
      err=>{ console.log(err);}
    );
      
  }

  updateRecord(form:NgForm)
  {
    this.service.putPaymentDetail().subscribe(
      res=>{ 
        this.resetForm(form);
        this.toastr.success('Successfully saved' ,'Payment details');
        this.service.refreshList();
     },
      err=>{ console.log(err);}
    );
    
  }
}
