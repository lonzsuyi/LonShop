import { GoodState } from './good';

export interface CartState {
    cart: Array<CartItem>
}

export interface CartItem {
    id: any,
    good: GoodState,
    quantity: number,
    status: boolean
}

export const ADD_CART = 'ADD_CART'
interface AddCartAction {
    type: typeof ADD_CART
    payload: CartItem
}
export const UPATE_CART = 'UPATE_CART'
interface UpdateCartAction {
    type: typeof UPATE_CART
    payload: CartItem
}
export const DEL_CART = 'DEL_CART'
interface DelCartAction {
    type: typeof DEL_CART
    payload: CartItem
}
export const CLEAN_CART = 'CLEAN_CART'
interface CleanCartAction {
    type: typeof CLEAN_CART
}

export type CartActionTypes = AddCartAction | UpdateCartAction | DelCartAction | CleanCartAction