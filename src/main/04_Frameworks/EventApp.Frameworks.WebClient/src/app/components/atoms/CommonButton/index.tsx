import React from "react";
import { useHistory } from "react-router-dom";
import { DefaultCommonButton } from "./styles";

export type CommonButtonProps = {
    text: string;
    onClick: (history: any) => void
}

export const CommonButton: React.FC<CommonButtonProps> = (props: CommonButtonProps) => {
    const history = useHistory();
    
    return (
        <DefaultCommonButton
            onClick={() => { props.onClick(history) }}>
            {props.text}
        </DefaultCommonButton>
    )
}