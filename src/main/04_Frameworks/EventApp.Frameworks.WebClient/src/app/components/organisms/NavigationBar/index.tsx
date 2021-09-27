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
                props.navigationItems
                    .filter(navigationItem => navigationItem.isVisible === undefined || navigationItem.isVisible)
                    .map((navigationItem, i) => (
                        <NavigationItemContainer key={i}>
                            <NavigationItem 
                                key={i}
                                {...navigationItem}/>
                        </NavigationItemContainer>
                    ))
            }
        </NavigationBarContainer>
    )
}