import { useEffect, useState } from "react";
import { Navigate, useNavigate, useParams } from "react-router-dom";
import { ApiEndPoints } from '../constants/AppConstants';
import axios from 'axios';

const AddNote = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [redirectToList, setRedirtectToList] = useState(false);
    const [note, setNote] = useState({
        id: 0,
        title: '',
        description: ''
    });
    useEffect(() => {
        loadNotes();
    }, [id]);

    const loadNotes = () => {
        if(id > 0)
        {
            let url = `${ApiEndPoints.Notes}/${id}`;
            axios.get(url)
                .then(resp => {
                    setNote(resp.data);
                })
                .catch(err => console.log(err));
        }        
    }

    const changeNotesHandler = (ev) => {
        setNote(prevValue => ({...prevValue, [ev.target.name]: ev.target.value}));
    }
    const handleSubmit = (ev) => {
        ev.preventDefault();
        let url = ApiEndPoints.Notes;
        
        if(id && id > 0)
            url = url + `/${id}`;
        let action = (!id)?axios.post(url, note):axios.put(url, note);
        
        action.then(resp => {
            
            if(resp.headers['location'])
            {
                setRedirtectToList(true);
                navigate('/notes');
            }
        })
        .catch(err => console.log(err));

    }
    return (
        <div className="notesForm">
            <form onSubmit={e => handleSubmit(e)}>
                <label htmlFor="title">Title:</label><br />
                <input type="text" id="title" name="title" onChange={ev => changeNotesHandler(ev)} value={note.title} /><br />
                <label htmlFor="desc">Description:</label><br />
                <textarea id="desc" name="description" onChange={ev => changeNotesHandler(ev)} rows="4" cols="50" type="text" value={note.description} /><br /><br />
                <input type="submit" value="Submit" />
            </form>              
            
        </div>
        
    );
};
export default AddNote;