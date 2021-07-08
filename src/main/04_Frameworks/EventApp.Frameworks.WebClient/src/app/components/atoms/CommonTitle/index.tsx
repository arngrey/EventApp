import React from "react";
import { CommonTitleContainer } from "./styles";

export type CommonTitleProps = {
    text: string;
}

export const CommonTitle: React.FC<CommonTitleProps> = (props: CommonTitleProps) => {
    return (
        <CommonTitleContainer>
            {props.text}
        </CommonTitleContainer>
    );
}