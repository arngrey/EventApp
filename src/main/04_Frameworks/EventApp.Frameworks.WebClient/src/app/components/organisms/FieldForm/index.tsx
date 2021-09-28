import React, { useState } from "react";
import { useHistory } from "react-router-dom";
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


export type FieldFormProps = {
    title: string;
    fields: Array<SelectFieldFormProps | InputFieldFormProps>
    onOk: (records: any, history: any) => void;
    onCancel: () => void;
}

export const FieldForm: React.FC<FieldFormProps> = (props: FieldFormProps) => {
    const history = useHistory();
    const [fieldRecords, setFieldRecords] = useState<FieldRecords>({});
    
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
                buttons={[
                    { text: "Ок", onClick: () => { props.onOk(fieldRecords, history) } }, 
                    { text: "Отмена", onClick: props.onCancel }
                ]} />
        </FieldFormContainer>
    );
}