"use client"
import {useState, useEffect} from 'react'
import { getEvents } from "../../api/events/eventService"
import CreateEventButton from "../../components/atoms/CreateEventButton";
import EventsModule from "../../components/atoms/modules/EventsModule"
import Modal from "../../components/atoms/modules/modal"

export default function EventPage() {
    const [events, setEvents] = useState([])
    const [isModalOpen, setIsModalOpen] = useState(false)

    useEffect(() => {
        (async () => {
            const data = await getEvents()
            setEvents(data)
        })
    }, [])

    console.log(events)

    const handleModalClose = () => {
        setIsModalOpen(false)
    }

    const handleModalOpen = () => {
        setIsModalOpen(true)
        console.log("open")
    }

    return (
        <>
    <div style={{display: isModalOpen ? "none" : "block"}}>
        {
            events.length > 0 ? (
                <EventsModule events={events}/>
                ) : 
                (
                    <div style={{display: "flex", justifyContent: "center", alignItems: "center", height: "100vh"}}>
                        <CreateEventButton onClick={handleModalOpen} />
                    </div>
            )
        }
    </div>
    <Modal isOpen={isModalOpen} onClose={handleModalClose}>
        This is a modal
    </Modal>
    </>
            )
}