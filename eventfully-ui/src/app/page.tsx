import EventsModule from "./components/atoms/modules/EventsModule"
import { getEvents } from "./api/events/eventService"


export default async function Home() {
    const events = await getEvents()
    console.log('Data:', events)
    
    return (
        <div style={{width: "35%"}}>
            <EventsModule events={events} />
        </div>
    )
      
}
