import cartReducer, { getandCreateCartItemASync } from '../../redux/cartSlice';
import { createAsyncThunk, configureStore } from '@reduxjs/toolkit';
import axios from 'axios';

import * as types from '../../constants/cart'

describe('cart reducer', () => {
    const initialState: types.CartState = {
        id: 0,
        cartItems: [],
        buyerId: ''
    };

    it('should handle initial state', () => {
        expect(cartReducer(undefined, { type: 'unknown' })).toEqual({
            id: 0,
            cartItems: [],
            buyerId: ''
        });
    });

})