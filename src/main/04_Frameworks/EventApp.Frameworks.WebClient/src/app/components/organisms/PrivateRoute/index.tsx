import React from "react";
import { Route, Redirect, RouteProps } from "react-router-dom";

export type PrivateRouteProps = {
    isAuthenticated: boolean;
    path: string;
} & RouteProps

export const PrivateRoute: React.FC<PrivateRouteProps> = ({ isAuthenticated, ...rest }) => (
    isAuthenticated ?
        (
            <Route 
                {...rest}
            />
        ) :
        <Redirect 
            to={{ 
                pathname: "/signin", 
                state: { from: rest.location } 
            }} />
    
)