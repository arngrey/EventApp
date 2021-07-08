import React from "react";
import { TableRowContainer, TableRowContainerProps } from "./styles";
import { TableCell } from "../../atoms/TableCell";


export type TableRowProps = {
    values: Array<string>
    containerProps: TableRowContainerProps
}

export const TableRow: React.FC<TableRowProps> = (props) => {
    return (
        <TableRowContainer
            height={props.containerProps.height}>
            {
                props.values.map((value, i) => (
                    <TableCell key={i} value={value}></TableCell>
                ))
            }
        </TableRowContainer>
    );
}