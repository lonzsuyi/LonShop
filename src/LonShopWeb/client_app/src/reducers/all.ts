import { combineReducers } from 'redux'

import authReducer from './authReduercer'
import cartReducer from './cartReducer'

export const reducers = combineReducers({
    authReducer,
    cartReducer
})

export type RootState = ReturnType<typeof reducers>