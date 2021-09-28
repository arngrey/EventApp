import React, { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from '../../../app/hooks';
import { loadHobbiesAsync, createHobbyAsync } from '../../../app/slice';
import { Table } from "../../../app/components/organisms/Table";
import { RegisterContainer } from "../styles";
import { FieldForm } from "../../../app/components/organisms/FieldForm";
import { Popup } from "../../../app/components/atoms/Popup";
import { useLocation } from "react-router-dom";
import { selectHobbies } from "../../selectors";

export const HobbyRegister: React.FC = () => {
    const dispatch = useAppDispatch();

    const location = useLocation();
    useEffect(() => {
        dispatch(loadHobbiesAsync())
    }, [location]);

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
                    { text: "Добавить", onClick: () => { setPopupVisibility(true); } }
                ] }} />
            <Popup isVisible={isPopupVisible}>
                <FieldForm 
                    title={"Создание хобби"}
                    fields={[
                        { name: "name", type: "input", props: { labelText: "Наименование" } },
                    ]}
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