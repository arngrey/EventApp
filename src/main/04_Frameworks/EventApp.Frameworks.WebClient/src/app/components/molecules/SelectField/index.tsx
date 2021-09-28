import React from "react";
import Select, { SingleValue, MultiValue } from "react-select";
import { SelectFieldContainer, SelectContainer } from "./styles";
import { FieldLabel } from "../../atoms/FieldLabel";

export type SelectFieldOption = {
    label: string;
    value: string;
}

export type SelectFieldProps = {
    labelText: string;
    isMultiple?: boolean;
    options: SelectFieldOption[];
    onChange: (newOption: SingleValue<SelectFieldOption> | MultiValue<SelectFieldOption>) => void;
}

export const SelectField: React.FC<SelectFieldProps> = props => (
    <SelectFieldContainer>
        <FieldLabel text={props.labelText} />
        <SelectContainer>
            <Select 
                isMulti={props.isMultiple === true}
                styles={{container: () => ({ width: "100%" })}}
                onChange={newOption => props.onChange(newOption)}
                options={props.options} />
        </SelectContainer>
    </SelectFieldContainer>
    
)