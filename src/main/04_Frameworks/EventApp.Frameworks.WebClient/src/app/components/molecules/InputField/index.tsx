import React from "react";
import { InputFieldContainer } from "./styles";
import { FieldLabel } from "../../atoms/FieldLabel";
import { FieldInput } from "../../atoms/FieldInput";

export type InputFieldProps = {
    labelText: string; 
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void
}

export const InputField: React.FC<InputFieldProps> = (props: InputFieldProps) => {
    return (
        <InputFieldContainer>
            <FieldLabel text={props.labelText} />
            <FieldInput onChange={ props.onChange } />
        </InputFieldContainer>
    )
}