import axios from 'axios'

// axios instance
const httpRequest = axios.create()

// interceptors applies to every ajax call
httpRequest.interceptors.request.use(
    function (config) {
        return config
    },
    function (err) {
        return Promise.reject(err)
    }
)

export default httpRequest