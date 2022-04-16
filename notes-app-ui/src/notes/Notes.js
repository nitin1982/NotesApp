import React, { useEffect, useState } from "react";
import Note from "./Note";
import data from "./data";
import { Navigate } from 'react-router-dom'
import { ApiEndPoints } from '../constants/AppConstants';
import axios from 'axios';

const Notes = () => {
    const [ addNotes, setAddNotes ] = useState(false);
    const [ notes, setNotes ] = useState([]);
    useEffect(() => {
        loadNotes();
    }, []);

    const loadNotes = () => {
        let url = ApiEndPoints.Notes;
        axios.get(url)
            .then(resp => {
                setNotes(...notes, resp.data);
            })
            .catch(err => console.log(err));
    }
    return (
        <>
            <h2>All Notes</h2>
            <button onClick={() => setAddNotes(true)}>Add New</button>
            {
                addNotes &&
                <Navigate to='../notes/Add'></Navigate>
            }
            
            <div>
                {
                    notes.map((no, idx) => 
                        <Note note={no} key={idx}></Note>
                    )
                }
            </div>
        </>
    );
};

export default Notes;