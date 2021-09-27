import React from "react";
import { Link } from "react-router-dom";
import { DefaultNavigationItem } from "./styles";

export type NavigationItemProps = { 
    title: string;
    path: string;
    isVisible?: boolean;
}

export const NavigationItem: React.FC<NavigationItemProps> = (props) => {
    return (
        <DefaultNavigationItem>
            <Link to={props.path}>
                {props.title}
            </Link>
        </DefaultNavigationItem>
    )
}