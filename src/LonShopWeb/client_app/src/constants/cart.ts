import { GoodState } from './good';

export interface CartState {
    id: number
    cartItems: Array<CartItem>
    buyerId: string
}

export interface CartItem {
    id: string,
    good: GoodState,
    quantity: number,
    status: boolean
}

export const SET_CART = 'SET_CART'
interface SetCartAction {
    type: typeof SET_CART
    payload: CartState
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

export type CartActionTypes = SetCartAction | AddCartAction | UpdateCartAction | DelCartAction | CleanCartAction