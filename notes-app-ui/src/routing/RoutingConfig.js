import React from "react";
import { Routes, Route } from "react-router-dom";
import Home from "../home/Home";
import AddNote from "../notes/AddNote";
import Notes from "../notes/Notes";

const RoutingConfig = () => {
    return (
        <Routes>
            <Route path='/' element={<Home />}></Route>
            <Route path='/notes/Add' element = {<AddNote />}></Route>
            <Route path='/notes/:id' element = {<AddNote />}></Route>
            <Route path='/notes' element = {<Notes />}></Route>
            
        </Routes>
    );
}

export default RoutingConfig;