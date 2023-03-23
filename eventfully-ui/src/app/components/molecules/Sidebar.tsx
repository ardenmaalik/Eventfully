'use client'

import Link from 'next/link'
import { Box, Container, List, ListItem } from '@mui/material'

export default function Sidebar() {
    return (
        <Container maxWidth="sm" sx={{bgcolor: '#929292', margin: 0, width: "250px", height: "100vh"}}>
            <Box sx={{ bgcolor: '#929292', color:"#FFF", height: "100%", width: "100%" }}>
                <List>
                    <ListItem>
                        Dashboard
                    </ListItem>
                    <ListItem>
                        <Link href="/pages/eventPage">Events</Link>
                    </ListItem>
                    <ListItem>
                        Profile
                    </ListItem>
                </List>
            </Box>
        </Container>
    )
}

