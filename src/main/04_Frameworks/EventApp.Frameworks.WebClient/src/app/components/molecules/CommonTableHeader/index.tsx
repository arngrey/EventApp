import React from "react";
import { CommonTableHeaderContainer } from "./styles";
import { CommonTableCell } from "../../atoms/CommonTableCell";

export type CommonTableHeaderProps = {
    columnNames: Array<string>;
}

export const CommonTableHeader: React.FC<CommonTableHeaderProps> = (props: CommonTableHeaderProps) => {
    return (
        <CommonTableHeaderContainer>
            {
                props.columnNames.map((columnName, i) => (
                    <CommonTableCell value={columnName} key={i}></CommonTableCell>
                ))
            }
        </CommonTableHeaderContainer>
    )
}