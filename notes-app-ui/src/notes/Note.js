import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import './notes.css';


const Note = ({note}) => {
    return (        
        <>
            <div className={note.priority == 1? 'importantNote card': 'card'}>
                <strong>{note.title}</strong>
                <p>{note.description}</p>                
                <Link to={'../notes/' + note.id}>Edit</Link>
            </div>
        </>
        
    );
}
export default Note;