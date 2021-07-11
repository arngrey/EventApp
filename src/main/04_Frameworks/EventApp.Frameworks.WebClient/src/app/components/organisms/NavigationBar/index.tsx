import React from "react";
import { NavigationItem, NavigationItemProps } from "../../molecules/NavigationItem";
import { NavigationBarContainer, NavigationItemContainer } from "./styles";

export type NavigationBarProps = {
    navigationItems: NavigationItemProps[];
}

export const NavigationBar: React.FC<NavigationBarProps> = (props) => {
    return (
        <NavigationBarContainer>
            {
                props.navigationItems.map((navigationItem, i) => (
                    <NavigationItemContainer key={i}>
                        <NavigationItem 
                            key={i}
                            path={navigationItem.path}
                            title={navigationItem.title}/>
                    </NavigationItemContainer>
                ))
            }
        </NavigationBarContainer>
    )
}