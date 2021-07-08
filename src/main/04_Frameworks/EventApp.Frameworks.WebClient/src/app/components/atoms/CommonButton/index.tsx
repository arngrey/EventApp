import React from "react";
import { DefaultCommonButton } from "./styles";

export type CommonButtonProps = {
    text: string;
    onClick: () => void
}

export const CommonButton: React.FC<CommonButtonProps> = (props: CommonButtonProps) => {
    return (
        <DefaultCommonButton
            onClick={() => {props.onClick()}}>
            {props.text}
        </DefaultCommonButton>
    )
}