import React, { useState } from "react";
import { CommonTitle } from "../../atoms/CommonTitle";
import { CommonButtonPanel } from "../../molecules/CommonButtonPanel";
import { InputField } from "../../molecules/InputField";
import { FieldFormContainer, FieldFormFieldsContainer, FieldFormTitleContainer } from "./styles";

type InputFieldRecords = Record<string, string>;

type InputFieldProps = {
    labelText: string;
    name: string;
}

export type FieldFormProps = {
    title: string;
    inputFields: Array<InputFieldProps>
    onOk: (records: any) => void;
    onCancel: () => void;
}

export const FieldForm: React.FC<FieldFormProps> = (props: FieldFormProps) => {
    const [inputFieldRecords, setInputFieldRecords] = useState<InputFieldRecords>({});
    
    return (
        <FieldFormContainer>
            <FieldFormTitleContainer>
                <CommonTitle 
                    text={props.title} />
            </FieldFormTitleContainer>
            <FieldFormFieldsContainer>
            {
                props.inputFields.map((inputField, i) => (
                    <InputField 
                        key={i}
                        labelText={inputField.labelText}
                        onChange={(e) => {
                            const newValue = e.target.value;
                            inputFieldRecords[inputField.name] = newValue
                            setInputFieldRecords(inputFieldRecords);
                        }} />
                ))
            }
            </FieldFormFieldsContainer>
            <CommonButtonPanel 
                buttons={[
                    { text: "Ок", onClick: () => { props.onOk(inputFieldRecords) } }, 
                    { text: "Отмена", onClick: props.onCancel }
                ]} />
        </FieldFormContainer>
    );
}