import * as types from './constants/auth'

export function setAuth(params: types.AuthState): types.AuthActionTypes {
    return {
        type: types.SET_AUTH,
        payload: params
    }
}

export function cleanAuth(): types.AuthActionTypes {
    return {
        type: types.CLEAN_AUTH
    }
}