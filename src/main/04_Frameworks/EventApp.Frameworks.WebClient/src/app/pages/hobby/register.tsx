import React, { useState } from "react";
import { useAppDispatch, useAppSelector } from '../../../app/hooks';
import { loadHobbiesAsync, createHobbyAsync, selectHobbies } from '../../../app/slice';
import { Table } from "../../../app/components/organisms/Table";
import { RegisterContainer } from "../styles";
import { FieldForm } from "../../../app/components/organisms/FieldForm";
import { Popup } from "../../../app/components/atoms/Popup";

export const HobbyRegister: React.FC = () => {
    const dispatch = useAppDispatch();
    const hobbies = useAppSelector(selectHobbies);
    const [isPopupVisible, setPopupVisibility] = useState<boolean>(false);

    return (
        <RegisterContainer>
            <Table
                title={"Список хобби"}
                columnNames={["Идентификатор", "Наименование"]}
                rows={hobbies.map((hobby: any) => [hobby.id, hobby.name])}
                rowHeight={"1rem"}
                headersHeight={"2rem"}
                buttonPanel={{ buttons: [ 
                    { text: "Обновить", onClick: () => { dispatch(loadHobbiesAsync()) } },
                    { text: "Добавить", onClick: () => { setPopupVisibility(true); } }
                ] }} />
            <Popup isVisible={isPopupVisible}>
                <FieldForm 
                    title={"Создание хобби"}
                    inputFields={[{ labelText: "Наименование", name: "name" }]}
                    onOk={async (records) => { 
                        await dispatch(createHobbyAsync(records["name"]));
                        await dispatch(loadHobbiesAsync());
                        setPopupVisibility(false);
                    }}
                    onCancel={() => { setPopupVisibility(false); }} /> 
            </Popup>
        </RegisterContainer>


    )
}