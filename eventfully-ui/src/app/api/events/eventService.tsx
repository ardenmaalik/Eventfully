import { urlEvents } from '../../endpoints'
import type { IFormInputs } from '../../components/atoms/forms/eventForm'
import axios from 'axios'

export async function getEvents() {
    let result = axios.get(`${urlEvents}/GetEvents`).then(({ data }) => data)
    return result
}

export async function postEvent(event: IFormInputs) {
    
    axios.post(urlEvents, event)
    .then((res) => console.log('Success:', res.status))
    
    
}
