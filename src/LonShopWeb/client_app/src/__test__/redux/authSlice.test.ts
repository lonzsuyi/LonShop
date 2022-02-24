import authReducer, { signInASync } from '../../redux/authSlice';
import { createAsyncThunk, configureStore } from '@reduxjs/toolkit';
import axios from 'axios';

import * as types from '../../constants/auth'

describe('auth reducer', () => {

    const initialState: types.AuthState = {
        token: '',
        username: '',
        expired: '',
        email: ''
    };

    it('should handle initial state', () => {
        expect(authReducer(undefined, { type: 'unknown' })).toEqual({
            token: null,
            username: null,
            expired: null,
            email: null
        });
    });

    it('should handle sign in', async () => {
        const myFunc = createAsyncThunk<string, { username: string; password: string }>('returns ID', async (params) => {
            const response = await axios.post('/auth/signin', params);
            return response.data;
        });
        const signInParams = {
            username: 'test1',
            password: 'testPw@'
        }
        const postSpy = jest.spyOn(axios, 'post').mockResolvedValueOnce({
            data: {
                token: '',
                username: '',
                expired: '',
                email: ''
            }
        })

        const store = configureStore({
            reducer: function (state = initialState, action) {
                switch (action.type) {
                    case 'returns ID/fulfilled':
                        return action.payload;
                    default:
                        return state;
                }
            }
        })

        await store.dispatch(myFunc(signInParams));
        expect(postSpy).toBeCalledWith('/auth/signin', signInParams);
        const state = store.getState();
        expect(state).toEqual({
            token: '',
            username: '',
            expired: '',
            email: ''
        })
    })

})