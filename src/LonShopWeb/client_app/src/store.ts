import { createStore as reduxCreateStore } from 'redux'

import { reducers }  from './reducers/all'
import middleware from './middleware/all'

const store = reduxCreateStore(reducers, middleware)

export default store