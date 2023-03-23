"use client"

import { useForm, SubmitHandler } from "react-hook-form"
import { postEvent } from "@/app/api/events/eventService"
import styled from "styled-components"


export type IFormInputs = {
    eventName: string,
    eventType: string,
    eventDescription: string,
    category: string,
    price: number,
    eventThumbnail: string,
    eventBanner: string,
    eventDate: string,
    eventTime: string
}

export default function EventForm() {
    const { register, handleSubmit, watch, formState: { errors } } = useForm<IFormInputs>(); 
    const onSubmit: SubmitHandler<IFormInputs> = async (data: IFormInputs) => {
        const eventObject: IFormInputs = {
            eventName: data.eventName,
            eventType: data.eventType,
            eventDescription: data.eventDescription,
            category: data.category,
            price: data.price,
            eventThumbnail: data.eventThumbnail,
            eventBanner: data.eventThumbnail,
            eventDate: "2023-03-22T17:13:30.041Z",
            eventTime: data.eventTime
        }

        await postEvent(eventObject)
    };

    return (
        <FormStyle>
            <form className="event-form" onSubmit={handleSubmit(onSubmit)}>
                <label>Event Name</label>
                <input {...register("eventName")} />
                <label>Event Type</label>
                <select {...register("eventType")} >
                    <option value="LiveStream">LiveStream</option>
                    <option value="OnDemand">On Demand</option>
                    <option value="LiveStream/OnDemand">LiveStream/OnDemand</option>
                </select>
                <label>Event Description</label>
                <input {...register("eventDescription")} />
                <label>Category</label>
                <input {...register("category")} />
                <label>Price</label>
                <input {...register("price")} />
                <label>Event Thumbnail</label>
                <input {...register("eventThumbnail")} />
                <label>Event Banner</label>
                <input {...register("eventBanner")} />
                <label>Event Date</label>
                <input {...register("eventDate")} />
                <label>Event Time</label>
                <input {...register("eventTime")} />
                <input type="submit"/>
            </form>
        </FormStyle>
    )
}

const FormStyle = styled.div`
    .event-form {
        display: flex;
        flex-direction: column;
        background-color: #929292;
        width: 400px;
        margin: 1rem;
        padding: 1rem;
        border-radius: 3%;
        input, select {
            width: 350px;
        }
    }
`

