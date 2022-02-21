import * as types from '../actions/constants/auth'

const initState: types.AuthState = {
    token: null,
    username: null,
    email: null,
    expired: null
}

const authReducer = (state = initState, action: types.AuthActionTypes) => {
    switch (action.type) {
        case types.SET_AUTH:
            state = {
                ...state,
                ...action.payload
            }
            break;
        case types.CLEAN_AUTH:
            state = {
                ...state,
                token: null,
                username: null,
                email: null,
                expired: null
            }
            break;

        default:
            break;
    }

    return state;
}

export default authReducer