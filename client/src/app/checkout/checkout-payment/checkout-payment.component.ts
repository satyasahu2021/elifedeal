import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';
import { IOrder } from 'src/app/shared/models/order';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent implements OnInit {
  @Input() checkoutForm: FormGroup;

  constructor(private basketService: BasketService, private checkoutService: CheckoutService,
    private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
  }


  async submitOrder() {
    // this.loading = true;
    const basket = this.basketService.getCurrentBasketValue();
    const orderToCreate = this.getOrderToCreate(basket);
    this.checkoutService.createOrder(orderToCreate).subscribe((order:IOrder) => {
      this.toastr.success('Order created successfully ');
      this.basketService.deleteLocalBasket(basket.id);
      const navigationExtras: NavigationExtras = {state: order};
      this.router.navigate(['checkout/success'], navigationExtras)
      console.log(order);
    }, error => {
  this.toastr.error(error.message);
  console.log(error);
    });
    // try {
      //const createdOrder = await this.createOrder(basket);
    //   const paymentResult = await this.confirmPaymentWithStripe(basket);
    //   if (paymentResult.paymentIntent) {
    //     this.basketService.deleteLocalBasket(basket.id);
    //     const navigationExtras: NavigationExtras = { state: createdOrder };
    //     this.router.navigate(['checkout/success'], navigationExtras);
    //   } else {
    //     this.toastr.error(paymentResult.error.message);
    //   }
    //   this.loading = false;
    // } catch (error) {
    //   console.log(error);
    //   this.loading = false;
    // }
  }

  private getOrderToCreate(basket: IBasket) {
    return {
      basketId: basket.id,
      deliveryMethodId: +this.checkoutForm.get('deliveryForm').get('deliveryMethod').value,
      shipToAddress: this.checkoutForm.get('addressForm').value
    };
  }



}
