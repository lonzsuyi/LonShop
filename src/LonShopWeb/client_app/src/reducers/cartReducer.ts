import * as types from '../actions/constants/cart'

const initState: types.CartState = {
    id: '',
    cart: [],
    buyerId: ''
}

const cartReducer = (state = initState, action: types.CartActionTypes) => {
    switch (action.type) {
        case types.SET_CART:
            state = {
                ...state,
                id: action.payload.id,
                cart: action.payload.cart
            }
            break;
        case types.ADD_CART:
            let addTmep;
            if (state.cart.findIndex((item) => item.good.id === action.payload.good.id) >= 0) {
                addTmep = state.cart.map((item) => {
                    if (item.good.id === action.payload.good.id) {
                        item.quantity = item.quantity + 1
                        return item
                    } else {
                        return item
                    }
                })
            } else {
                addTmep = [...state.cart, action.payload]
            }
            state = {
                ...state,
                cart: addTmep
            }
            break;
        case types.UPATE_CART:
            let updateTemp = state.cart.map((item) => {
                if (item.id === action.payload.id) {
                    return action.payload
                } else {
                    return item
                }
            })
            state = {
                ...state,
                cart: updateTemp
            }
            break;
        case types.DEL_CART:
            let delTemp = state.cart.filter((item) => {
                return action.payload.id !== item.id
            })
            state = {
                ...state,
                cart: delTemp
            }
            break;
        case types.CLEAN_CART:
            state = {
                ...state,
                cart: []
            }
            break;

        default:
            break;
    }

    return state;
}

export default cartReducer