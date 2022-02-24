import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit'
import type { RootState } from './store'

import * as types from '../constants/auth'
import * as authRequest from '../api/authRequest'

const initialState: types.AuthState = {
    token: null,
    username: null,
    email: null,
    expired: null
}

export const signInASync = createAsyncThunk(
    'auth/signInASync',
    async (params: any) => {
        const response = await authRequest.signIn(params.username, params.password);
        return response.data
    })

export const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setAuth: (state, action: PayloadAction<types.AuthState>) => {
            state = {
                ...state,
                ...action.payload
            }
        },
        cleanAuth: (state) => {
            state = {
                ...state,
                token: null,
                username: null,
                email: null,
                expired: null
            }
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(signInASync.fulfilled, (state, action) => {
                const result = action.payload.result
                state.token = result.token
                state.username = result.username
            });
    }
})

export const { setAuth, cleanAuth } = authSlice.actions

export const selectAuth = (state: RootState) => state.auth

export default authSlice.reducer