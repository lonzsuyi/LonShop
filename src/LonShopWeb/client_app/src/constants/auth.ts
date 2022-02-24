export interface AuthState {
    token: string | null | undefined
    username: string | null | undefined
    email: string | null | undefined
    expired: string | null | undefined
}

export const SET_AUTH = 'SET_AUTH'
interface SetAuthAction {
    type: typeof SET_AUTH
    payload: AuthState
}

export const CLEAN_AUTH = 'CLEAN_AUTH'
interface CleanAuthAction {
    type: typeof CLEAN_AUTH
}

export type AuthActionTypes = SetAuthAction | CleanAuthAction