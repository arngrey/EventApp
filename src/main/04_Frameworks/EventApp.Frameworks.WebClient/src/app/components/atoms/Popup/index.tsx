import React from "react";
import { DefaultPopup } from "./styles";

export type PopupProps = React.PropsWithChildren<{
    isVisible: boolean;
}>

export const Popup: React.FC<PopupProps> = (props) => {
    return (
        <DefaultPopup isVisible={props.isVisible}>
            {props.children}
        </DefaultPopup>
    )
}