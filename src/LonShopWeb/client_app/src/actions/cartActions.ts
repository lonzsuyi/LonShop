import * as types from '../actions/constants/cart'

export function setCart(params: types.CartState): types.CartActionTypes {
    return {
        type: types.SET_CART,
        payload: params
    }
}

export function addCart(params: types.CartItem): types.CartActionTypes {
    return {
        type: types.ADD_CART,
        payload: params
    }
}

export function udpateCart(params: types.CartItem): types.CartActionTypes {
    return {
        type: types.UPATE_CART,
        payload: params
    }
}

export function delCart(params: types.CartItem): types.CartActionTypes {
    return {
        type: types.DEL_CART,
        payload: params
    }
}

export function cleanCart(): types.CartActionTypes {
    return {
        type: types.CLEAN_CART
    }
}