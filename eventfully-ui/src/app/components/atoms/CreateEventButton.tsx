"use client"

import styled from 'styled-components'

interface ButtonProps {
    onClick: () => void
}

const CreateEventButton: React.FC<ButtonProps> = ({onClick}) => {

    return (
        <CreateEventButtonStyle onClick={onClick}>
            <button className="create-event-btn" style={{color: "white", width: "100%", height: "100%", backgroundColor: "transparent", border: "none"}}>
                Create an event
            </button>
        </CreateEventButtonStyle>
    )
}

export default CreateEventButton

const CreateEventButtonStyle = styled.div`
    display: flex;
    justify-content: center;
    align-items: center;
    height: 150px;
    width: 150px;
    background-color: none;
    border: 1px #FFF dashed;
    border-radius: 3%;

    button {
        cursor: pointer;
    }
`
