import { CartItem } from './cart';

export interface OrderParamsState {
    cart: Array<CartItem>
    username: string
    currency: string
}