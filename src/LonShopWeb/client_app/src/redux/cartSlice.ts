import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit'
import type { RootState } from './store'

import * as types from '../constants/cart'
import * as cartRequest from '../api/cartRequest'

export const getandCreateCartItemASync = createAsyncThunk(
    'cart/getandCreateCartItemASync',
    async () => {
        const response = await cartRequest.getOrCreateCart();
        return response.data
    })

export const addCartItemASync = createAsyncThunk(
    'cart/addCartItemASync',
    async (params: types.CartItem) => {
        const response = await cartRequest.addGood(params);
        return response.data
    })

export const updateCartASync = createAsyncThunk(
    'cart/updateCartASync',
    async (params: types.CartState) => {
        const response = await cartRequest.updateCart(params);
        return response.data
    })

export const delCartASync = createAsyncThunk(
    'cart/delCartASync',
    async (params: number) => {
        const response = await cartRequest.delCart(params);
        return response
    })

const initialState: types.CartState = {
    id: 0,
    cartItems: [],
    buyerId: ''
}

export const cartSlice = createSlice({
    name: 'cart',
    initialState,
    reducers: {
        setCart: (state, action: PayloadAction<types.CartState>) => {
            state = {
                ...state,
                id: action.payload.id,
                cartItems: action.payload.cartItems
            }
        },
        addCartItem: (state, action: PayloadAction<types.CartItem>) => {
            let addTmep;
            if (state.cartItems.findIndex((item) => item.good.id === action.payload.good.id) >= 0) {
                addTmep = state.cartItems.map((item) => {
                    if (item.good.id === action.payload.good.id) {
                        item.quantity = item.quantity + 1
                        return item
                    } else {
                        return item
                    }
                })
            } else {
                addTmep = [...state.cartItems, action.payload]
            }
            state = {
                ...state,
                cartItems: addTmep
            }
        },
        udpateCart: (state, action: PayloadAction<types.CartItem>) => {
            let updateTemp = state.cartItems.map((item) => {
                if (item.id === action.payload.id) {
                    return action.payload
                } else {
                    return item
                }
            })
            state = {
                ...state,
                cartItems: updateTemp
            }
        },
        delCartItem: (state, action: PayloadAction<types.CartItem>) => {
            let delTemp = state.cartItems.filter((item) => {
                return action.payload.id !== item.id
            })
            state = {
                ...state,
                cartItems: delTemp
            }
        },
        cleanCart: (state) => {
            state = {
                ...state,
                cartItems: []
            }
        }
    },
    extraReducers: (builder) => {
        builder.addCase(getandCreateCartItemASync.fulfilled, (state, action) => {
            const result = action.payload.result
            state.buyerId = result.buyerId
            state.cartItems = result.items
            state.id = result.id

        }).addCase(addCartItemASync.fulfilled, (state, action) => {
            const result = action.payload.result
            state.buyerId = result.buyerId
            state.cartItems = result.items
            state.id = result.id

        }).addCase(updateCartASync.fulfilled, (state, action) => {
            const result = action.payload.result
            state.buyerId = result.buyerId
            state.cartItems = result.items
            state.id = result.id

        }).addCase(delCartASync.fulfilled, (state, action) => {
            const data = action.payload
            state.cartItems = []
            state.buyerId = ""
            state.id = 0
        })
    }
})

export const { setCart, addCartItem, udpateCart, delCartItem, cleanCart } = cartSlice.actions

export const selectCart = (state: RootState) => state.cart

export default cartSlice.reducer