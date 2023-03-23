"use client"
import {useEffect} from 'react'
import Link from "next/link"
import {getEvents} from "../../../api/events/eventService"
import { Container, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from "@mui/material"


function createData(
    name: string,
    date: number,
    size: number,
  ) {
    return { name, date, size};
  }
  
  const rows = [
    createData('Frozen yoghurt', 159, 6.0),
    createData('Ice cream sandwich', 237, 9.0),
    createData('Eclair', 262, 16.0),
    createData('Cupcake', 305, 3.7),
    createData('Gingerbread', 356, 16.0),
  ];

  export interface IEventData {
    eventId: number;
    eventName: string;
    eventType: string;
    eventDescription: string;
    category: string;
    price: number;
    eventThumbnail: string;
    eventBanner: string;
    eventDate: string;
    eventTime: string;
  }
  
  interface EventsModuleProps {
    events: IEventData[];
  }

export default function EventsModule( {events}: EventsModuleProps) {
    
    return (
        <TableContainer component={Paper} sx={{bgcolor: "#929292", m: 2, p: 2}}>
                <Table sx={{ minWidth: 350 }} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Event Name</TableCell>
                            <TableCell align="right">Date</TableCell>
                            <TableCell align="right">Price</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                {events.map((event) => (
                            <TableRow
                            key={event.eventName}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    {event.eventName}
                                </TableCell>
                                <TableCell align="right">
                                    {event.eventDate}
                                </TableCell>
                                <TableCell align="right">
                                    {event.price}
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
    )
}
