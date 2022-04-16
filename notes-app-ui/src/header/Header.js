import React from "react";
import { Link } from 'react-router-dom';

const Header = () => {
    return (
        <nav>
            <ul>
                <li>
                    <Link to='notes'>Notes</Link>                    
                </li>
                <li>                    
                    <Link to='/'>Home</Link>
                </li>
            </ul>
        </nav>
    );
}
export default Header;