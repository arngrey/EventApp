import React from "react";
import { TableHeaderContainer } from "./styles";
import { TableCell } from "../../atoms/TableCell";

export type TableHeaderProps = {
    columnNames: Array<string>;
}

export const TableHeader: React.FC<TableHeaderProps> = (props: TableHeaderProps) => {
    return (
        <TableHeaderContainer>
            {
                props.columnNames.map((columnName, i) => (
                    <TableCell value={columnName} key={i}></TableCell>
                ))
            }
        </TableHeaderContainer>
    )
}