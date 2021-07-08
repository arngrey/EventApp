import React from "react";
import { DefaultFieldInput } from "./styles";

export type FieldInputProps = {
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void
}

export const FieldInput: React.FC <FieldInputProps> = (props: FieldInputProps) => {
    return (
        <DefaultFieldInput onChange={(e) => { props.onChange(e); }}/>
    )
}