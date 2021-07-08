import React from "react";
import { DefaultFieldLabel } from "./styles";

export type FieldLabelProps = {
    text: string
}

export const FieldLabel: React.FC <FieldLabelProps> = (props: FieldLabelProps) => {
    return (
        <DefaultFieldLabel>
            {props.text}
        </DefaultFieldLabel>
    )
}