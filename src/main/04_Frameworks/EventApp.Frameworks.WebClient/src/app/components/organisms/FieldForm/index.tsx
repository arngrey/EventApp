import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { CommonButtonProps } from "../../atoms/CommonButton";
import { CommonTitle } from "../../atoms/CommonTitle";
import { CommonButtonPanel } from "../../molecules/CommonButtonPanel";
import { InputField, InputFieldProps } from "../../molecules/InputField";
import { SelectField, SelectFieldProps } from "../../molecules/SelectField";
import { FieldFormContainer, FieldFormFieldsContainer, FieldFormTitleContainer } from "./styles";

type FieldRecords = Record<string, string | string[]>;

type FieldProps = {
    name: string;
}

export type SelectFieldFormProps = FieldProps
& {
    type: "select"
    props: Omit<SelectFieldProps, "onChange">
}

export type InputFieldFormProps = FieldProps
& {
    type: "input"
    props: Omit<InputFieldProps, "onChange">
}

export type FieldFormButtonProps = 
    Omit<CommonButtonProps, "onClick"> 
    & { 
        onClick: (record:any, history: any) => void; 
    };


export type FieldFormProps = {
    title: string;
    fields: Array<SelectFieldFormProps | InputFieldFormProps>;
    buttons: Array<FieldFormButtonProps>;
}

export const FieldForm: React.FC<FieldFormProps> = (props: FieldFormProps) => {
    const history = useHistory();
    const [fieldRecords, setFieldRecords] = useState<FieldRecords>({});
    const buttons = props.buttons
        .map(button => ({
            ...button,
            onClick: button.onClick.bind(null, fieldRecords)
        }))
    
    return (
        <FieldFormContainer>
            <FieldFormTitleContainer>
                <CommonTitle 
                    text={props.title} />
            </FieldFormTitleContainer>
            <FieldFormFieldsContainer>
            {
                props.fields.map((field, i) => {
                    switch (field.type) {
                        case "input":
                            return (
                                <InputField 
                                    {...field.props} 
                                    key={i}
                                    onChange={e => {
                                        const newValue = e.target.value;
                                        fieldRecords[field.name] = newValue;
                                        setFieldRecords(fieldRecords);
                                    }} />
                            );
                        case "select":
                            return (
                                <SelectField 
                                    {...field.props}
                                    key={i}
                                    onChange={newOption => {
                                        if (newOption === null) {
                                            fieldRecords[field.name] = "";
                                        } else if (Array.isArray(newOption)) {
                                            fieldRecords[field.name] = (newOption as any[]).map(option => option.value);
                                        } else {
                                            fieldRecords[field.name] = (newOption as any).value;
                                        }

                                        setFieldRecords(fieldRecords);
                                    }} />
                            );
                        default:
                            return null;
                    }
                    
                })
            }
            </FieldFormFieldsContainer>
            <CommonButtonPanel 
                buttons={buttons} />
        </FieldFormContainer>
    );
}